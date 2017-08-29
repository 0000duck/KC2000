using FrameworkContracts;
using IOInterface;
using LevelEditor.Model;
using Newtonsoft.Json;
using Render.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BaseTypes;

namespace LevelEditor
{
    public class ModelExporter
    {
        public static void Export(List<IElement> geometry)
        {
            CenterizeModel(geometry);

            Model.Model model = new Model.Model
            {
                Submodels = MapSubmodels(geometry),
                CollisionModel = CollisionModelExporter.GetShape(geometry)
            };
            Save(model);
        }

        private static void Save(Model.Model model)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;

            string fileName = System.Configuration.ConfigurationManager.AppSettings["ModelFileName"];
            if (File.Exists($"models\\{fileName}.mod"))
            {
                File.Delete($"models\\{fileName}.mod");
            }
            
            using (StreamWriter sw = new StreamWriter($"models\\{fileName}.mod"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, model);
            }
        }

        private static List<Submodel> MapSubmodels(List<IElement> geometry)
        {
            List <Submodel> models = new List<Submodel>();

            Dictionary<string, List<IElement>> groupedElements = GroupElements(geometry);

            PolygonExporter polygonExporter = new PolygonExporter();

            foreach (string texture in groupedElements.Keys)
            {
                Submodel subModel = new Submodel { Texture = texture.Split('\\').Last() };

                List<Polygon> polygons = new List<Polygon>();

                foreach(IElement element in groupedElements[texture])
                {
                    List<Polygon> subPolygons = polygonExporter.CreatePolygons((IVisualParameters)element.Parameters, element.Orientation);

                    foreach(Polygon pol in subPolygons)
                    {
                        AddPosition(pol, element.StartPosition);
                    }

                    polygons.AddRange(subPolygons);
                }

                subModel.Polygons = polygons;
                models.Add(subModel);
            }
            
            return models;
        }

        private static void AddPosition(Polygon pol, Position3D startPosition)
        {
            foreach(Vertex v in pol.Vertices)
            {
                v.Position.X += (float)startPosition.PositionX;
                v.Position.Y += (float)startPosition.PositionZ;
                v.Position.Z += (float)startPosition.PositionY;
            }
        }

        private static Dictionary<string, List<IElement>> GroupElements(List<IElement> geometry)
        {
            Dictionary<string, List<IElement>> groupedElements = new Dictionary<string, List<IElement>>();

            foreach (IElement element in geometry)
            {
                if (groupedElements.Keys.Contains(((IVisualParameters)element.Parameters).TextureFolder))
                    groupedElements[((IVisualParameters)element.Parameters).TextureFolder].Add(element);
                else
                    groupedElements.Add(((IVisualParameters)element.Parameters).TextureFolder, new List<IElement> { element });
            }

            return groupedElements;
        }
        private static void CenterizeModel(List<IElement> geometry)
        {
            double minX = 10000, minY = 10000, maxX = -10000, maxY = -10000;

            foreach (IElement element in geometry)
            {
                double elementMaxX = element.StartPosition.PositionX + (element.Parameters.SideLengthX / 2.0);
                double elementMinX = element.StartPosition.PositionX - (element.Parameters.SideLengthX / 2.0);
                double elementMaxY = element.StartPosition.PositionY + (element.Parameters.SideLengthY / 2.0);
                double elementMinY = element.StartPosition.PositionY - (element.Parameters.SideLengthY / 2.0);

                if (elementMaxX > maxX)
                    maxX = elementMaxX;

                if (elementMaxY > maxY)
                    maxY = elementMaxY;

                if (elementMinX < minX)
                    minX = elementMinX;

                if (elementMinY < minY)
                    minY = elementMinY;
            }

            double correctionX = 0, correctionY = 0;

            correctionX = (-maxX - minX) / 2.0;
            correctionY = (-maxY - minY) / 2.0;

            foreach (IElement element in geometry)
            {
                element.StartPosition.PositionX += correctionX;
                element.StartPosition.PositionY += correctionY;
            }
        }
    }
}

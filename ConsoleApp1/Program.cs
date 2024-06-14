using ConsoleApp1.Models;
using System.Text.Json;
using System.Collections.Generic;
using ListToTreeJsonConverter.Objects;
using ConsoleApp1.ObjectMapper;
using ListToTreeJsonConverter.Builds.Build.Interfaces;
using ListToTreeJsonConverter.Builds.Directors;
using ListToTreeJsonConverter.Builds.Build;
using ListToTreeJsonConverter.Utils;

internal class Program
{
    private static void Main(string[] args)
    {
       Example1();
    }

    private static void Example1()
    {

        List<TreeBuilder> modules = new List<TreeBuilder>();
        List<WebModule> webModules;

        //ejemplo una lista que llegaria un controlador
        using (var context = new SeguridadContext())
        {
            webModules = context.WebModules.ToList();
        }

        // ejemplo de como realizar un mapper del objeto que esta llegando 
        foreach (var moduleDB in webModules)
        {
            modules.Add(new Modules()
            {
                Id = moduleDB.WebModuleId,
                FatherId = moduleDB.WebModuleFather,
                WebModuleTitle = moduleDB.WebModuleTitle,
                WebModuleUrl = moduleDB.WebModuleUrl,
                
            });
        }

        IGenericTree genericTree = new GenericTreeBuild(modules);
        GenericTreeDirector genericTreeDirector = new GenericTreeDirector();

        var listTransform = genericTreeDirector.Construct(genericTree).ListconvertedTree;


        var json = JsonSerializer.Serialize(listTransform, new JsonSerializerOptions
        {
            WriteIndented = true, // Opcional: para formatear el JSON,
            Converters = { new PolymorphicJsonConverter<TreeBuilder>() } // para que el json contenga del objecto que abstrae la clase TreeBuilder
        });


        Console.WriteLine(json);
    }

}
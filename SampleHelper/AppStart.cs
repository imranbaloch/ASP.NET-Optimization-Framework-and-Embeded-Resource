using System;
using System.Web.Mvc;
using ImranB;
using System.Web.Routing;
using System.Web.Optimization;
using System.Web.Hosting;
        [assembly: WebActivator.PostApplicationStartMethod(typeof(AppStart), "Start")]

        namespace ImranB
        {
            public static class AppStart
            {
                public static void Start()
                {
                    ConfigureRoutes();
                    ConfigureBundles();
                }

                private static void ConfigureBundles()
                {
                    BundleTable.VirtualPathProvider = new EmbeddedVirtualPathProvider(HostingEnvironment.VirtualPathProvider);
                    BundleTable.Bundles.Add(new ScriptBundle("~/ImranB/Embedded/Js")
                        .Include("~/ImranB/Embedded/NewTextBox1.js")
                        .Include("~/ImranB/Embedded/NewTextBox2.js")
                        );
                    BundleTable.Bundles.Add(new StyleBundle("~/ImranB/Embedded/Css")
                        .Include("~/ImranB/Embedded/NewTextBox1.css")
                        .Include("~/ImranB/Embedded/NewTextBox2.css")
                        );
                }

                private static void ConfigureRoutes()
                {
                    RouteTable.Routes.Insert(0,
                        new Route("ImranB/Embedded/{file}.{extension}",
                            new RouteValueDictionary(new { }),
                            new RouteValueDictionary(new { extension = "css|js" }),
                            new EmbeddedResourceRouteHandler()
                        ));
                }
            }
        }
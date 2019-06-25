using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using SiteInformationBuild.Sites;
using SiteInformationBuild;

namespace ParseProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ISiteInformation> sites = new List<ISiteInformation>() { new LigaNet(), new LeviiBereg(), new Segodnya(), new Strana(), new PravdaCom(), new Ukrinform(), new Unian(), new CensorNet(), new Obozrevatel(), new Telegraf() };
            int progres = 0;
            Console.WriteLine("The program running, wait, please...");
            foreach (ISiteInformation site in sites)
            {
                site.CreateHtmlFile();
                site.CreateNewsUrlsList();
                site.CreateDirectoryToSave();
                progres += 10;
                Console.WriteLine(progres + "%");
            }

            Console.WriteLine("The files are complete, check the folder \"Output data\"");

            Console.ReadKey();
        }
    }
}

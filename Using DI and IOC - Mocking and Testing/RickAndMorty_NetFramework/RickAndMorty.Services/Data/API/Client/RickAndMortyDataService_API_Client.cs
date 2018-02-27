using Newtonsoft.Json;
using RickAndMorty.Services.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace RickAndMorty.Services.Data.Api.Client
{
    public class RickAndMortyDataService_API_Client
    {
        string _rootApiUrl;

        private Resources _resources;
        private Resources Resources
        {
            get
            {
                if (_resources == null)
                    _resources = GetResources();
                return _resources;
            }
        }

        public RickAndMortyDataService_API_Client(string RootApiUrl)
        {
            _rootApiUrl = RootApiUrl;
        }


        public IEnumerable<Character> GetCharacters()
        {
            return GetObjects<Character>(Resources.characters);
        }
        public IEnumerable<Location> GetLocations()
        {
            return GetObjects<Location>(Resources.locations);
        }
        public IEnumerable<Episode> GetEpisodes()
        {
            return GetObjects<Episode>(Resources.episodes);
        }

        private IEnumerable<T> GetObjects<T>(string url) 
        {
            List<T> objects = new List<T>();
            string nextUrl = url;
            while (!string.IsNullOrWhiteSpace(nextUrl))
            {
                Console.WriteLine($"Geting {nextUrl}");
                WebRequest req = WebRequest.Create(nextUrl);
                req.Method = "GET";
                WebResponse resp = req.GetResponse();
                using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                {
                    string respBody = sr.ReadToEnd();
                    Results<T> results = JsonConvert.DeserializeObject<Results<T>>(respBody);
                    nextUrl = results.info.next;
                    objects.AddRange(results.results);
                }
            }
            return objects;
        }
        private Resources GetResources()
        {
            WebRequest req = WebRequest.Create(_rootApiUrl);
            req.Method = "GET";
            WebResponse resp = req.GetResponse();
            using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
            {
                string respBody = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<Resources>(respBody);
            }
        }
    }
}

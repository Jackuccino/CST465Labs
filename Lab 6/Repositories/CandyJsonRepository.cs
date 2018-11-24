using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_5.Models;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Lab_5.Repositories
{
    public class CandyJsonRepository : ICandyRepository
    {
        private List<Candy> _candyList;
        private readonly string _candyDir;
        private TreaterSettings _Settings;

        public CandyJsonRepository(IOptions<TreaterSettings> treaterConfig)
        {
            _Settings = treaterConfig.Value;
            _candyDir = System.IO.Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "Candy.json");
            _candyList = GetList();
        }

        public List<Candy> GetList()
        {
            using (StreamReader sr = new StreamReader(_candyDir))
            {
                string jsonContent = sr.ReadToEnd();
                _candyList = JsonConvert.DeserializeObject<List<Candy>>(jsonContent);
            }

            return _candyList;
        }

        public void Insert(string name)
        {
            Candy candy = new Candy
            {
                Id = _candyList.Max(x => x.Id) + 1,
                ProductName = name
            };
            _candyList.Add(candy);

            using (StreamWriter sw = new StreamWriter(_candyDir))
            {
                sw.Write(JsonConvert.SerializeObject(_candyList));
            }
        }

        public void Delete(int id)
        {
            if (_Settings.AllowCandyDelete == false)
            {
                throw new InvalidOperationException();
            }

            _candyList.Remove(_candyList.Find(x => x.Id == id));

            using (StreamWriter sw = new StreamWriter(_candyDir))
            {
                sw.Write(JsonConvert.SerializeObject(_candyList));
            }
        }
    }
}

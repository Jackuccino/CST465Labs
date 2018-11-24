using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lab_5.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Lab_5.Repositories
{
    public class CostumeJsonRepository : ICostumeRepository
    {

        private List<Costume> _costumeList;
        private readonly string _costumeDir;
        private TreaterSettings _Settings;
        
        public CostumeJsonRepository(IOptions<TreaterSettings> treaterConfig)
        {
            _Settings = treaterConfig.Value;
            _costumeDir = System.IO.Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "Costumes.json");
            _costumeList = GetList();
        }

        public List<Costume> GetList()
        {
            using (StreamReader sr = new StreamReader(_costumeDir))
            {
                string jsonContent = sr.ReadToEnd();
                _costumeList = JsonConvert.DeserializeObject<List<Costume>>(jsonContent);
            }

            return _costumeList;
        }

        public void Insert(string name)
        {
            Costume costume = new Costume
            {
                Id = _costumeList.Max(x => x.Id) + 1,
                CostumeName = name
            };
            _costumeList.Add(costume);

            using (StreamWriter sw = new StreamWriter(_costumeDir))
            {
                sw.Write(JsonConvert.SerializeObject(_costumeList));
            }
        }
        
        public void Delete(int id)
        {
            if (_Settings.AllowCostumeDelete == false)
            {
                throw new InvalidOperationException();
            }

            _costumeList.Remove(_costumeList.Find(x => x.Id == id));

            using (StreamWriter sw = new StreamWriter(_costumeDir))
            {
                sw.Write(JsonConvert.SerializeObject(_costumeList));
            }
        }
    }
}

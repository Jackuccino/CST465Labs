using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lab_5.Models;
using Newtonsoft.Json;

namespace Lab_5.Repositories
{
    public class TreaterJsonRepository : ITreaterRepository
    {
        private List<Treater> _treaterList;
        private readonly string _treaterDir;

        public TreaterJsonRepository()
        {
            _treaterList = new List<Treater>();
            _treaterDir = System.IO.Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "Treaters.json");
        }

        public List<Treater> GetList()
        {
            using (StreamReader sr = new StreamReader(_treaterDir))
            {
                string jsonContent = sr.ReadToEnd();
                _treaterList = JsonConvert.DeserializeObject<List<Treater>>(jsonContent);
            }

            return _treaterList;
        }

        public void Insert(Treater treater)
        {
            _treaterList.Add(treater);

            using (StreamWriter sw = new StreamWriter(_treaterDir))
            {
                sw.Write(JsonConvert.SerializeObject(_treaterList));
            }
        }
    }
}

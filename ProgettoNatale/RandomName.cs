using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.IO;

namespace ProgettoNatale
{
    public class RandomName
    {
        /// <summary>
        /// Classe per la lista del file "names.json"
        /// </summary>
        class NameList
        {
            public string[] boys { get; set; }
            public string[] girls { get; set; }
            public string[] last { get; set; }

            public NameList()
            {
                boys = new string[] { };
                girls = new string[] { };
                last = new string[] { };
            }
        }

        Random rand;
        List<string> Male;
        List<string> Female;
        List<string> Last;

        /// <summary>
        /// Inizializza una nuova istanza della classe RandomName
        /// </summary>
        /// <param name="rand">Un Random utilizzato per scegliere a caso</param>
        public RandomName(Random rand)
        {
            this.rand = rand;
            NameList l = new NameList();

            JsonSerializer serializer = new JsonSerializer();

            using (StreamReader reader = new StreamReader("names.json"))
            using (JsonReader jreader = new JsonTextReader(reader))
            {
                l = serializer.Deserialize<NameList>(jreader);
            }

            Male = new List<string>(l.boys);
            Female = new List<string>(l.girls);
            Last = new List<string>(l.last);
        }

        /// <summary>
        /// Ritorna un nuovo nome a random
        /// </summary>
        /// <param name="sex">Il sesso della persona. true per i maschi, false per le ragazze</param>
        /// <param name="middle">Quantità di secondi nomi da generare</param>
        /// <param name="isInital">I secondi nomi devono essere inizializzati?</param>
        /// <returns>Il nome generato come una stringa</returns>
        public string Generate(Sex sex, int middle = 0, bool isInital = false)
        {
            string first = sex == Sex.Male ? Male[rand.Next(Male.Count)] : Female[rand.Next(Female.Count)]; // Determina se dobbiamo dare un nome maschile o femminile
            string last = Last[rand.Next(Last.Count)]; //Prende il cognome

            List<string> middles = new List<string>();

            for (int i = 0; i < middle; i++)
            {
                if (isInital)
                {
                    middles.Add("ABCDEFGHIJKLMNOPQRSTUVWXYZ"[rand.Next(0, 25)].ToString() + "."); //Prende una lettera a caso e gli mette un punto per segnalare il secondo nome
                }
                else
                {
                    middles.Add(sex == Sex.Male ? Male[rand.Next(Male.Count)] : Female[rand.Next(Female.Count)]); //Prende un nome a random che sta bene con il sesso scelto
                }
            }

            StringBuilder b = new StringBuilder();
            b.Append(first + " "); //Mette uno spazio tra i nomi
            foreach (string m in middles)
            {
                b.Append(m + " ");
            }
            b.Append(last);

            return b.ToString();
        }

        /// <summary>
        /// Genera una lista di nomi a random
        /// </summary>
        /// <param name="number">Numero di nomi da generare</param>
        /// <param name="maxMiddleNames">Numero massimo di secondi nomi</param>
        /// <param name="sex">Il sesso dei nomi, se null è a random</param>
        /// <param name="initials">Per vedere se i secondi nomi devono essere inizializzati, se null viene randomizzato</param>
        /// <returns>Lista di stringhe di nomi</returns>
        public List<string> RandomNames(int number, int maxMiddleNames, Sex? sex = null, bool? initials = null)
        {
            List<string> names = new List<string>();

            for (int i = 0; i < number; i++)
            {
                if (sex != null && initials != null)
                {
                    names.Add(Generate((Sex)sex, rand.Next(0, maxMiddleNames + 1), (bool)initials));
                }
                else if (sex != null)
                {
                    bool init = rand.Next(0, 2) != 0;
                    names.Add(Generate((Sex)sex, rand.Next(0, maxMiddleNames + 1), init));
                }
                else if (initials != null)
                {
                    Sex s = (Sex)rand.Next(0, 2);
                    names.Add(Generate(s, rand.Next(0, maxMiddleNames + 1), (bool)initials));
                }
                else
                {
                    Sex s = (Sex)rand.Next(0, 2);
                    bool init = rand.Next(0, 2) != 0;
                    names.Add(Generate(s, rand.Next(0, maxMiddleNames + 1), init));
                }
            }

            return names;
        }
    }

    public enum Sex
    {
        Male,
        Female
    }
}

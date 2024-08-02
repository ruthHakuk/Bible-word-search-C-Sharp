
using BibleDal;
using BibleEnteties;
using Newtonsoft.Json;
using PersonInformation;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.IO;
namespace BibleBLL
{
    public class ClassBLL
    {
        private ClassDal f { get; set; }

        public ClassBLL()
        {
            this.f = new ClassDal();
        }

        public string op()
        {
            return f.GetBibleText();
        }


        //לוכד שגיאות לכל הפונרקציות-בודק שהמשתמש לא מכניס מילה באהגלית אם כן הוא נותן לו שגיאה


        //פונקציה שמחזירה מיקומים של מילים
        public List<int> SearchWordIndexes(string w)
        {
            string text = f.GetBibleText();
            List<int> list = new List<int>();
            string[] words = text.Split(' ');
            char FirstHebChar = (char)1488;
            char LastHebChar = (char)1514;
            if (w[0] >= FirstHebChar && w[0] <= LastHebChar)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Contains(w))
                    {
                        list.Add(i);
                    }
                }
                return list;
            }
            else
            {
                throw new ArgumentException("Access denied - You must insert only in hebrew.");
            }
        }


        //פןנקציה שמחזירה פרשה,פסוק,פרק ,חומש של מילה 
        public List<string> findExactLocation(string w)
        {
            string book = "";
            string chapter = "";
            string parasha = "";
            string pasuk = "";
            List<string> list = new();
            char FirstHebChar = (char)1488;
            char LastHebChar = (char)1514;
            if (w[0] >= FirstHebChar && w[0] <= LastHebChar)
            {
                string text1 = f.GetBibleText();
                string[] text = text1.Split(' ');

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].Contains('^'))
                    {
                        parasha = text[i + 2].Replace("!", "");
                    }
                    else if (text[i].Contains('~'))
                    {
                        book = text[i + 2];
                        chapter = text[i + 1].Replace("!", "");

                    }
                    else if (text[i].Contains('!'))
                    {

                        pasuk = text[i + 1];
                        int p1 = pasuk.IndexOf("{");
                        int p2 = pasuk.IndexOf("}");
                        pasuk = pasuk.Substring(p1, p2);



                    }
                    else if (text[i] == w)
                    {
                        Location loc = new(book, chapter, parasha, pasuk);
                        string finalText = loc.ToString().Replace("\r\n", "");
                        list.Add(finalText);

                    }

                }
                if (list.Count == 0)
                {
                    list.Add("Sorry the word you provided isn't exsist in the torha,we reccomend you to try another word");
                }

                return list;
            }
            else
            {
                throw new ArithmeticException("Access denied - You must insert only in hebrew.");
            }

        }



        // פונקציה שמחפשתלכל דמות בתורה  עם מי הוא\היא דיבר\ה לפי 
        // "Y אל X וידבר" 
        //שמות מומלצים לחיפוש:משה,אהרן,פרעה,שרה(שרי),אברהם(אברם),יצחק,יעקב,לאה,רבקה,רחל
        public List<string> findIntractuon(string name)
        {
            List<string> list = new();
            string text1 = f.GetBibleText();

            char FirstHebChar = (char)1488;
            char LastHebChar = (char)1514;
            if (name[0] >= FirstHebChar && name[0] <= LastHebChar)
            {
                string detailesOfPerson = TranserToObject(name);
                if (detailesOfPerson != null)
                    list.Add($"פרטים על הדמות :{(string)detailesOfPerson}");

                string[] text = text1.Split(" ");

                for (int i = 1; i < text.Length - 1; i++)
                {
                    if (text[i].Equals(name))
                    {
                        if (text[i - 1].Contains("וידבר") || text[i - 1].Contains("ותאמר") || text[i - 1].Contains("ויאמר") && text[i + 1].Contains("אל"))
                        {
                            string p = text[i + 2];
                            if (p.Equals("בני") || p.Equals("זקני"))
                            {
                                p = p + " " + "ישראל";
                            }
                            list.Add($"דיבר עם :{p}");
                        }
                        else if (text[i - 1].Contains("וידבר") || text[i - 1].Contains("ותאמר") || text[i - 1].Contains("ויאמר") && text[i + 1][0].Equals("ל"))
                        {

                            string p = text[i + 1];
                            if (p.Equals("בני") || p.Equals("זקני"))
                            {
                                p = p + " " + "ישראל";
                            }
                            if (p.Equals("ראשי") || p.Equals("כל"))
                            {
                                p = p + " " + "העם";

                            }
                            list.Add($"דיבר עם :{p}");

                        }

                    }

                }
                if (list.Count == 0)
                {
                    list.Add("Sorry the name you provided doesnt have any results,we reccomend you to try another name");
                }
                return list;
            }
            else
            {
                throw new ArithmeticException("Access denied - You must insert only in hebrew.");
            }

        }


        //ממירה את קובץ הג'ייסון לאובייקט ואחר כך מחפשת שם מסויים בתוך הקובץ
        //(בקובץ הג'ייסון שלי ישנם דמויות מהתנך ועל כל דמות ישנם פרטים)
        //השימוש בזה שבתוך פונקציית החיפוש כשמכניסים שם של דמות לחיפוש הוא מביא לה את הפרטים על אותו דמות 
        // ואם אין פרטים בקובץ על הדמות הזאת זה כותב לו את זה 
        public string TranserToObject(string name)
        {
            string jsonText = f.GetJasonText();
            Detailes detailes = new Detailes();
            string answer = "its empty";
            string answer1 = "there is no detailes on this person";

            if (jsonText != null)
            {

                detailes = JsonConvert.DeserializeObject<Detailes>(jsonText);
            }
            else
            {
                return answer; 
            }

            string[] personDetailes = detailes?.people?.ToArray();

            if (personDetailes != null)
            {
                foreach (var person in personDetailes)
                {
                    if (name == person.Split(' ')[0])
                    {
                        return person;
                    }
                }
            }

            return answer1; 
        }



       



    }
}
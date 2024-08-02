using System.Threading.Tasks;

namespace BibleEnteties
{
    public class Location
    {
        public  string book { get; set; }
        public string chapter { get; set; }
        public string parasha { get; set; }
        public string pasuk { get; set; }



        public Location(string book, string chapter, string parasha, string pasuk)
        {
            this.book = book;
            this.chapter = chapter;
            this.parasha = parasha;
            this.pasuk = pasuk;
        }


     public override string ToString()
        {
            return $"{this.book},{this.chapter},{this.parasha},{this.pasuk}";
        }
    }

    
}
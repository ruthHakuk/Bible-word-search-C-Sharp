namespace BibleDal
{
    public class ClassDal
    {
        //קריאת קובץ התנך
       
        public string GetBibleText()
        {
            string path = @"C:\Users\user\Downloads\פרוייקט תנך\tora.txt";

            try
            {
                return File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null; 
            }
        }
        //קריאת קובץ הג'ייסון שבתוכו יש דמויות מהתנך עם פרטים עליהם
        public  string GetJasonText()
        {
            string filePath = "C:\\Users\\user\\Documents\\'שנה ב\\C#\\BibleDal\\Detailes.json";
            if (filePath!=null)
            {
                string jsonContent = File.ReadAllText(filePath);
                return jsonContent;
            }
            return null;
        }
    }
}
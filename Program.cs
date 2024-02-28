const string path = $@"C:\\Users\\victo\\Downloads\\sampleData.csv";

var csvReader = new CsvReader().Read(path);

Console.ReadKey();

public class CsvReader
{
    public CsvData Read(string path)
    {
        const string Separator = ",";
        using (var stremReader = new StreamReader(path))
        {
            var columns = stremReader.ReadLine().Split(Separator);

            var rows = new List<string[]>();
            
            while (!stremReader.EndOfStream)
            {
                var cellsInRows = stremReader.ReadLine().Split(Separator);
                rows.Add(cellsInRows);
            }

            return new CsvData(columns, rows);
        }
    }
}

public class CsvData
{
    public string[] Columns { get; }
    public IEnumerable<string[]> Rows { get; }
    
    public CsvData(string[] columns, IEnumerable<string[]> rows)
    {
        Columns = columns;
        Rows = rows;
    }
}
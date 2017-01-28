using System;
using System.IO;

namespace Exceptioner
{
    public class OutputFile
    {

        public enum OutputType
        {
            Console,
            Csv,
        };

        public OutputType Type = OutputType.Csv;

        public StreamWriter writer;

        public OutputFile(string path, OutputType type = OutputType.Csv)
        {
            new FileInfo(path).Delete();
            writer = new StreamWriter(path);
            this.Type = type;

            this.CreateHeader();
        }


        public void Append(string value)
        {
            if (this.Type == OutputType.Console)
            {
                Console.WriteLine(value);
            }
            else
            {
                this.writer.WriteLine(value);
            }
        }

        private void Close()
        {
            writer.Flush();
            writer.Close();
        }

        private void CreateHeader()
        {
            if (this.Type == OutputType.Csv)
            {
                this.Append(string.Join(",", this.GetColumns()));
            }
        }

        private string[] GetColumns()
        {
            return new string[] {
                "Id",
                "Guid",
                "Name",
                "FullName",
                "SearchFrequency",
                "Url",
                "Description",
                "Assembly 1",
                "Assembly 2",
                "Assembly 3",
                "Assembly 4",
                "Assembly 5",
                "Assembly 6",
                "Assembly 7",
                "Assembly 8",
                "Assembly 9",
            };
        }

    }
}

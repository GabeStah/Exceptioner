using System;

namespace Exceptioner
{
    public class Exception
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public int SearchFrequency { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }

        public Exceptioner.TypeHierarchy Parents { get; set; }

        public Exception()
        {
        
        }

        public string OutputToFile(OutputFile.OutputType outputType = OutputFile.OutputType.Csv)
        {
            if (outputType == OutputFile.OutputType.Csv)
            {
                string assemblies = string.Join(",", this.Parents);
                string[] data = {
                    this.Id.ToString(),
                    this.Guid.ToString(),
                    this.Name,
                    this.FullName,
                    this.SearchFrequency.ToString(),
                    this.Url,
                    this.Description,
                    assemblies,
                };
                return string.Join(",", data);
            }
            return null;
        }
    }
}

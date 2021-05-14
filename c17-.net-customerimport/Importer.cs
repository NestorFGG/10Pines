using System.IO;

namespace C17_.Net_CustomerImport
{
    public abstract class Importer
    {
        protected Stream _fileStream;
        protected string _line;
        protected string[] _record;

        protected Importer(Stream fileStream)
        {
            _fileStream = fileStream;
        }

        public void Execute()
        {
            var lineReader = new StreamReader(_fileStream);
            
            _line = lineReader.ReadLine();

            while (_line != null)
            {
                GetRecord();
                ImportRecord();

                _line = lineReader.ReadLine();
            }

            _fileStream.Close();
        }
        protected abstract void GetRecord();
        protected abstract void ImportRecord();
        protected abstract void ImportAddress();
        protected abstract void ImportCustomer();
        protected abstract bool IsAddressRecord();
        protected abstract bool IsCustomerRecord();
    }
}
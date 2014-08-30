using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UndirectedGraphService;

namespace UndirectedGraphWebServices
{
    public class DataLoaderWS : IDataLoaderWS
    {

        #region Private Members

        private IDataLoaderXmlService _dataLoaderXml;

        #endregion

        #region Class Constructor

        public DataLoaderWS()
        {
            _dataLoaderXml = new DataLoaderXmlService();
        }

        #endregion

        #region Public Methods

        public bool DataLoadXml(string path)
        {

            return _dataLoaderXml.DataLoadXml(path);
        }

        #endregion

    }
}
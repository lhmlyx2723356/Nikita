using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

 namespace Nikita.Report.WinForm
{
    class RdlGenerator
    {
        private float m_widthInches;

        private List<string> m_allFields;

        private List<string> m_rowFields;
        private List<string> m_columnFields;
        private List<string> m_summarizedFields;
         
        private List<string> m_selectedFields;
 
        public List<string> SelectedFields
        {
            get { return m_selectedFields; }
            set { m_selectedFields = value; }
        }

        public List<string> RowFields
        {
            get { return m_rowFields; }
            set { m_rowFields = value; }
        }

        public List<string> ColumnFields
        {
            get { return m_columnFields; }
            set { m_columnFields = value; }
        }

        public List<string> SummarizedFields
        {
            get { return m_summarizedFields; }
            set { m_summarizedFields = value; }
        }

        public float WidthInches
        {
            get { return m_widthInches; }
            set { m_widthInches = value; }
        }

        public List<string> AllFields
        {
            get { return m_allFields; }
            set { m_allFields = value; }
        }

        private Rdl.Report CreateReport()
        {
            Rdl.Report report = new Rdl.Report();
            report.Items = new object[] 
                {
                    CreateDataSources(),
                    CreateBody(),
                    CreateDataSets(),
                    m_widthInches + "in",
                };
            report.ItemsElementName = new Rdl.ItemsChoiceType37[]
                { 
                    Rdl.ItemsChoiceType37.DataSources, 
                    Rdl.ItemsChoiceType37.Body,
                    Rdl.ItemsChoiceType37.DataSets,
                    Rdl.ItemsChoiceType37.Width,
                };
            return report;
        }

        private Rdl.DataSourcesType CreateDataSources()
        {
            Rdl.DataSourcesType dataSources = new Rdl.DataSourcesType();
            dataSources.DataSource = new Rdl.DataSourceType[] { CreateDataSource() };
            return dataSources;
        }

        private Rdl.DataSourceType CreateDataSource()
        {
            Rdl.DataSourceType dataSource = new Rdl.DataSourceType();
            dataSource.Name = "DummyDataSource";
            dataSource.Items = new object[] { CreateConnectionProperties() };
            return dataSource;
        }

        private Rdl.ConnectionPropertiesType CreateConnectionProperties()
        {
            Rdl.ConnectionPropertiesType connectionProperties = new Rdl.ConnectionPropertiesType();
            connectionProperties.Items = new object[]
                {
                    "",
                    "SQL",
                };
            connectionProperties.ItemsElementName = new Rdl.ItemsChoiceType[]
                {
                    Rdl.ItemsChoiceType.ConnectString,
                    Rdl.ItemsChoiceType.DataProvider,
                };
            return connectionProperties;
        }

        private Rdl.BodyType CreateBody()
        {
            Rdl.BodyType body = new Rdl.BodyType();
            body.Items = new object[]
                {
                    CreateReportItems(),
                    "1in",
                };
            body.ItemsElementName = new Rdl.ItemsChoiceType30[]
                {
                    Rdl.ItemsChoiceType30.ReportItems,
                    Rdl.ItemsChoiceType30.Height,
                };
            return body;
        }

        private Rdl.ReportItemsType CreateReportItems()
        {
            Rdl.ReportItemsType reportItems = new Rdl.ReportItemsType();
            MatrixRdlGenerator matrixGen = new MatrixRdlGenerator();
            matrixGen.ColumnFields = m_columnFields;
            matrixGen.RowFields = m_rowFields;
            matrixGen.SummarizedFields = m_summarizedFields;
            reportItems.Items = new object[] { matrixGen.CreateMatrix() };
            return reportItems;
        }

        private Rdl.DataSetsType CreateDataSets()
        {
            Rdl.DataSetsType dataSets = new Rdl.DataSetsType();
            dataSets.DataSet = new Rdl.DataSetType[] { CreateDataSet() };
            return dataSets;
        }

        private Rdl.DataSetType CreateDataSet()
        {
            Rdl.DataSetType dataSet = new Rdl.DataSetType();
            dataSet.Name = "MyData";
            dataSet.Items = new object[] { CreateQuery(), CreateFields() };
            return dataSet;
        }

        private Rdl.QueryType CreateQuery()
        {
            Rdl.QueryType query = new Rdl.QueryType();
            query.Items = new object[] 
                {
                    "DummyDataSource",
                    "",
                };
            query.ItemsElementName = new Rdl.ItemsChoiceType2[]
                {
                    Rdl.ItemsChoiceType2.DataSourceName,
                    Rdl.ItemsChoiceType2.CommandText,
                };
            return query;
        }

        private Rdl.FieldsType CreateFields()
        {
            Rdl.FieldsType fields = new Rdl.FieldsType();

            fields.Field = new Rdl.FieldType[m_allFields.Count];
            for (int i = 0; i < m_allFields.Count; i++)
            {
                fields.Field[i] = CreateField(m_allFields[i]);
            }

            return fields;
        }

        private Rdl.FieldType CreateField(String fieldName)
        {
            Rdl.FieldType field = new Rdl.FieldType();
            field.Name = fieldName;
            field.Items = new object[] { fieldName };
            field.ItemsElementName = new Rdl.ItemsChoiceType1[] { Rdl.ItemsChoiceType1.DataField };
            return field;
        }

        public void WriteXml(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Rdl.Report));
            serializer.Serialize(stream, CreateReport());
        }
    }
}

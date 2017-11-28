﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovenaLibrary.SqlGenerators
{
    public class SqliteSqlGenerator : BaseSqlGenerator
    {
        public SqliteSqlGenerator()
        {
            base.openingColumnMark = '"';
            base.closingColumnMark = '"';

            //Website for type mappings:
            //https://www.devart.com/dotconnect/sqlite/docs/DataTypeMapping.html
            Dictionary<string, bool> mappings = new Dictionary<string, bool>();
            mappings.Add("boolean", false);
            mappings.Add("smallint", false);
            mappings.Add("int16", false);
            mappings.Add("int", false);
            mappings.Add("int32", false);
            mappings.Add("INTEGER", false);
            mappings.Add("int64", false);
            mappings.Add("REAL", false);
            mappings.Add("NUMERIC", false);
            mappings.Add("decimal", false);
            mappings.Add("money", false);
            mappings.Add("currency", false);
            mappings.Add("date", true);
            mappings.Add("time", true);
            mappings.Add("datetime", true);
            mappings.Add("smalldate", true);
            mappings.Add("datetimeoffset", true);
            mappings.Add("time", true);
            mappings.Add("TEXT", true);
            mappings.Add("ntext", true);
            mappings.Add("char", true);
            mappings.Add("nchar", true);
            mappings.Add("varchar", true);
            mappings.Add("nvarchar", true);
            mappings.Add("string", true);

            base.typeMappings = mappings;
        }

        public override string createSql(bool distinct, string[] columns, string table, string[,] criteria, string[] groupBy, string[] orderBy, string limit, string offset, bool asc)
        {
            StringBuilder sql = new StringBuilder("");
            sql.Append(createSELECTClause(distinct, columns));
            sql.Append(createFROMClause(table));
            sql.Append(createWHEREClause(criteria));
            sql.Append(createGROUPBYCluase(groupBy));
            sql.Append(createORDERBYCluase(orderBy, asc));
            sql.Append(createLimitClause(limit));
            sql.Append(createOffsetClause(offset));
            return sql.ToString().Replace("  ", " ");
        }
    }
}
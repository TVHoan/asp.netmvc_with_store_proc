using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using netmvc.Dto.Base;
using netmvc.Models;

namespace netmvc.Repository
{
    public class ProcRepository: IProcRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /*
        private TEntity Entity { get; set; }
        */

        
        public async Task<int> ExcuteProc<TInput>(TInput input, string ProcName)
        {
            var props = input.GetType().GetProperties();
            int propsLenth = props.Length;
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            string command = "exec " + ProcName;
            foreach (var item in props.Select((prop, i) => new { i, prop }))
            {
                string propName ="@" + item.prop.Name;
                sqlParameters.Add(new SqlParameter(propName , item.prop.GetValue(input)));
                command += " " +propName;
                if (item.i + 1 < propsLenth)
                {
                    command += ",";
                }
            }

            var paramss = sqlParameters.ToArray();
            return await db.Database.ExecuteSqlCommandAsync(command,paramss);
        }

    }
}
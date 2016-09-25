using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSbacground_MainQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryClient.ClientFactory query_client = new QueryClient.ClientFactory(1);
            query_client.Execute();
        }
    }
}

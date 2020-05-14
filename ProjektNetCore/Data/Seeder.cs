using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Covid.Models;
using Newtonsoft.Json.Serialization;
using Covid.Data;
public static class Seeder
{
    public static void Seedit(string jsonData,
                              IServiceProvider serviceProvider)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ContractResolver = new PrivateSetterContractResolver()
        };
        var events =
         JsonConvert.DeserializeObject<Records>(
           jsonData, settings);
        using (
         var serviceScope = serviceProvider
           .GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = serviceScope
                          .ServiceProvider.GetService<CovidContext>();
            if (!context.Records.Any())
            {
                context.AddRange(events);
                context.SaveChanges();
            }
        }
    }
}
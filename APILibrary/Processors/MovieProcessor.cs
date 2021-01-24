using APILibrary.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APILibrary.Processors
{
    public class MovieProcessor
    {
         
        public static async Task<IEnumerable<MovieModel>> LoadMovie(int year, string title) 
       {
            string url = "";
            if (year > 0 && title.Length > 0)
            {
                url = $"Movies?year={year}&title={title}";
            }
            else if (year == 0 && title.Length > 0)
            {
                url = $"Movies?title={title}";
            }
            else
            {
               throw new Exception("You have to specify title") ;
            }
            using (
                HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url) )
            {
                if(response.IsSuccessStatusCode)
                {
                    // get movies from json and convert to array
                    var movies = await response.Content.ReadAsAsync<IEnumerable<MovieModel>>();

                    return movies;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
                
        }
    }
}

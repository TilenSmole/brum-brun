using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace petrol.Pages
{
    public class IndexModel : PageModel
    {
        public string? GasPrice { get; set; }

        public async Task OnGetAsync()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");

            string html = await client.GetStringAsync(
                "https://www.petrol.si/prodajna-mesta/2529-bs-ig-bencinski-servis");

            var match = Regex.Match(html,
                @"Q Max 95[\s\S]*?<p class=""location-detail__service-item-price"">\s*([\d,]+)\s*€");

            if (match.Success)
                GasPrice = match.Groups[1].Value.Trim();
        }
    }
}

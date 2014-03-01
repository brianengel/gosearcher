﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;

namespace GoSearcher.Business.Html
{
    public class SteamMarketParser
    {
        public SteamMarketParser()
        {

        }

        public List<SteamMarketEntry> Parse(string resultsHtml)
        {
            List<SteamMarketEntry> results = new List<SteamMarketEntry>();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(resultsHtml);

            HtmlNodeCollection links = doc.DocumentNode.SelectNodes("//a[@class='market_listing_row_link']");
            foreach (var link in links)
            {
                SteamMarketEntry entry = new SteamMarketEntry();

                HtmlNode img = link.SelectSingleNode(".//img[@class='market_listing_item_img']");
                HtmlNode name = link.SelectSingleNode(".//span[@class='market_listing_item_name']");
                HtmlNode qty = link.SelectSingleNode(".//span[@class='market_listing_num_listings_qty']");

                HtmlNode priceNode = qty.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling;
                string priceRaw = HttpUtility.HtmlDecode(priceNode.InnerHtml.Trim());
                decimal price = Convert.ToDecimal(GeneralRegex.NonNumbers.Replace(priceRaw, String.Empty));

                entry.ImageUrl = img.Attributes["src"].Value;
                entry.Name = name.InnerText;
                entry.Quantity = Convert.ToInt32(GeneralRegex.NonNumbers.Replace(qty.InnerText, String.Empty));
                entry.Price = price;
                entry.Url = link.Attributes["href"].Value;

                results.Add(entry);
            }

            return results;
        }
    }
}
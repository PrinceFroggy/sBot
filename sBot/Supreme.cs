using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net;
using System.Collections;
using System.Threading;
using HtmlAgilityPack;

namespace sBot
{
    //*****************************************PROPERTY OF ANDREW JUSTIN SOLESA*
    //**************************************************************************

    public class SupremeBot
    {
        public class SupremeProposal : List<SupremeProposal.SupremeRequest>
        {
            public struct SupremeRequest
            {
                internal string Tag { get; set; }
                internal string Size { get; set; }
                internal string Design { get; set; }
            }

            public SupremeProposal()
            {
                this.Clear();
            }

            internal void Add(string _tag)
            {
                this.Add(new SupremeRequest() { Tag = _tag });
            }

            internal void Add(string _tag, string _size)
            {
                this.Add(new SupremeRequest() { Tag = _tag, Size = _size });
            }

            internal void Add(string _tag, string _size, string _design)
            {
                this.Add(new SupremeRequest() { Tag = _tag, Size = _size, Design = _design });
            }
        }

        public class SupremeInformation : List<SupremeInformation.SupremeBill>
        {
            public struct SupremeBill
            {
                internal string Name { get; set; }
                internal string Email { get; set; }
                internal string Address { get; set; }
                internal string Zip { get; set; }
                internal string Tel { get; set; }
                internal string Country { get; set; }
                internal string State { get; set; }
                internal string City { get; set; }

                internal string Type { get; set; }
                internal string Number { get; set; }
                internal string Expiry { get; set; }
                internal string Cvv { get; set; }
            }

            public SupremeInformation() 
            {
                this.Clear();
            }

            internal void Add(string _name, string _email, string _address, string _zip, string _tel, string _country, string _state, string _city, string _type, string _number, string _expiry, string _cvv)
            {
                this.Add(new SupremeBill() { Name = _name, Email = _email, Address = _address, Zip = _zip, Tel = _tel, Country = _country, State = _state, City = _city, Type = _type, Number = _number, Expiry = _expiry, Cvv = _cvv });
            }
        }

        internal Form1 Form1 { get; set; }

        internal SupremeProposal Proposal { get; set; }
        internal SupremeInformation Information { get; set; }

        public bool Executed { get; set; }
        internal bool Heartbeat { get; set; }

        internal Thread Logic;

        public SupremeBot()
        {
            Form1 = null;

            Proposal = null;
            Information = null;

            Executed = false;
        }

        public SupremeBot(Form1 _form1, SupremeProposal _proposal, SupremeInformation _information)
        {
            if (_form1 != null && _proposal != null && _information != null)
            {
                Form1 = _form1;

                Proposal = _proposal;
                Information = _information;

                Executed = true;
            }
        }

        internal void Start()
        {
            Heartbeat = true;

            Logic = new Thread(new ThreadStart(AI));

            Logic.Start();
        }

        internal void Stop()
        {
            Heartbeat = false;

            Logic.Abort();
        }

        void AI()
        {
            HtmlAgilityPack.HtmlDocument Doc = null;
            HtmlAgilityPack.HtmlDocument Tmp = null;

            List<int> Items = Enumerable.Range(0, Proposal.Count).ToList();
            List<int> PurchasedItems = new List<int>();

            while (Heartbeat)
            {
                foreach (int Item in Items.Reverse<int>())
                {
                    #region Artificial Intelligence

                    try
                    {
                        #region Propsal & Supreme - Tag value verifiction comparer navigator

                        SupremeList List = null;

                        if (!string.IsNullOrEmpty(Proposal[Item].Tag))
                        {
                            List = new SupremeList(0);

                            if (!List.Executed) continue;

                            Doc = null;

                            for (int a = 0; a < List.Count; a++)
                            {
                                if (Compute(Proposal[Item].Tag, List[a].Name) < 4 || List[a].Name.Contains(Proposal[Item].Tag))
                                {
                                    Doc = new HtmlAgilityPack.HtmlDocument();
                                    Doc.LoadHtml(new WebClient().DownloadString("http://www.supremenewyork.com" + List[a].Href));

                                    Form1.webBrowser1.Navigate(new Uri("about:blank"));
                                    Form1.webBrowser1.Navigate("http://www.supremenewyork.com" + List[a].Href);

                                    break;
                                }
                            }

                            if (Doc == null)
                            {
                                continue;
                            }
                        }

                        #endregion

                        #region Propsal & Supreme - Design value verification comparer navigator

                        SupremeList Design = null;

                        if (!string.IsNullOrEmpty(Proposal[Item].Design))
                        {
                            Design = new SupremeList(Doc.DocumentNode.SelectNodes("//div[@id='details'] //li"));

                            if (!Design.Executed) continue;

                            Tmp = null;

                            for (int s = 0; s < Design.Count; s++)
                            {
                                if (Compute(Proposal[Item].Design, Design[s].Design) < 1 || Design[s].Design.Contains(Proposal[Item].Design))
                                {
                                    if (!Design[s].Sold)
                                    {
                                        Tmp = new HtmlAgilityPack.HtmlDocument();
                                        Tmp.LoadHtml(new WebClient().DownloadString("http://www.supremenewyork.com" + Design[s].Href));

                                        Form1.webBrowser1.Navigate(new Uri("about:blank"));
                                        Form1.webBrowser1.Navigate("http://www.supremenewyork.com" + Design[s].Href);

                                        break;
                                    }
                                }
                            }

                            if (Tmp == null)
                            {
                                continue;
                            }
                        }

                        #endregion

                        Thread.Sleep(3000);

                        #region Proposal & Supreme - Size value verification event

                        #region List value event

                        System.Windows.Forms.HtmlElement SupremeSize = null;

                        if (!string.IsNullOrEmpty(Proposal[Item].Size))
                        {
                            SupremeSize = Form1.SupremeSize;

                            System.Windows.Forms.HtmlElementCollection Options = SupremeSize.Children;

                            foreach (System.Windows.Forms.HtmlElement element in Options)
                            {
                                if (Compute(Proposal[Item].Size, element.InnerText) < 1)
                                {
                                    SupremeSize.SetAttribute("value", GetSubstringByString("=", ">", element.OuterHtml));
                                    SupremeSize.InvokeMember("onchange");
                                    SupremeSize.InvokeMember("click");

                                    break;
                                }
                            }
                        }

                        #endregion

                        #endregion

                        Thread.Sleep(3000);

                        #region Supreme - Add to cart button event

                        #region Button event

                        System.Windows.Forms.HtmlElement SupremeAddButton = null;

                        SupremeAddButton = Form1.SupremeAddButton;

                        System.Windows.Forms.HtmlElementCollection AddButton = SupremeAddButton.Children;

                        foreach (System.Windows.Forms.HtmlElement element in AddButton)
                        {
                            if (element.GetAttribute("value").Equals("add to cart"))
                            {
                                element.InvokeMember("submit");
                                element.InvokeMember("click");

                                break;
                            }
                        }

                        #endregion

                        #endregion

                        Thread.Sleep(3000);

                        Form1.webBrowser1.Navigate("https://www.supremenewyork.com/checkout");

                        Thread.Sleep(3000);

                        #region Supreme - Billing/Shipping information event

                        #region Textbox value event

                        System.Windows.Forms.HtmlElement SupremeCartAddress = null;

                        SupremeCartAddress = Form1.SupremeCartAddress;

                        SupremeCartAddress.Document.GetElementById("order_billing_name").SetAttribute("value", Information[0].Name);
                        SupremeCartAddress.Document.GetElementById("order_email").SetAttribute("value", Information[0].Email);
                        SupremeCartAddress.Document.GetElementById("order_tel").SetAttribute("value", Information[0].Tel);
                        SupremeCartAddress.Document.GetElementById("bo").SetAttribute("value", Information[0].Address);
                        SupremeCartAddress.Document.GetElementById("order_billing_zip").SetAttribute("value", Information[0].Zip);
                        SupremeCartAddress.Document.GetElementById("order_billing_city").SetAttribute("value", Information[0].City);

                        #endregion

                        #region List value event

                        mshtml.HTMLSelectElement SupremeCountry = null;

                        if (Information[0].Country != "USA")
                        {
                            SupremeCountry = Form1.SupremeCountry;

                            SupremeCountry.selectedIndex = 1;

                            SupremeCountry.click();

                            SupremeCountry.FireEvent("onchange");
                        }
                        
                        // you can copy the format below to select any EUROPEAN country here...as of right now this code only works for the NORTH AMERICAN shipping

                        System.Windows.Forms.HtmlElement SupremeState = null;

                        SupremeState = Form1.SupremeState;

                        System.Windows.Forms.HtmlElementCollection State = SupremeState.Children;

                        foreach (System.Windows.Forms.HtmlElement element in State)
                        {
                            if (element.InnerText == Information[0].State)
                            {
                                SupremeState.SetAttribute("value", Information[0].State);
                                SupremeState.InvokeMember("onchange");
                                SupremeState.InvokeMember("click");

                                break;
                            }
                        }

                        #endregion

                        #endregion

                        Thread.Sleep(3000);

                        #region Supreme - Credit card information event

                        #region List value event

                        System.Windows.Forms.HtmlElement SupremeType = null;

                        SupremeType = Form1.SupremeType;

                        System.Windows.Forms.HtmlElementCollection Type = SupremeType.Children;

                        foreach (System.Windows.Forms.HtmlElement element in Type)
                        {
                            if (element.InnerText == Information[0].Type)
                            {
                                SupremeType.SetAttribute("value", FormatType(Information[0].Type));
                                SupremeType.InvokeMember("onchange");
                                SupremeType.InvokeMember("click");

                                break;
                            }
                        }

                        System.Windows.Forms.HtmlElement SupremeMonth = null;

                        SupremeMonth = Form1.SupremeMonth;

                        System.Windows.Forms.HtmlElementCollection Month = SupremeMonth.Children;

                        foreach (System.Windows.Forms.HtmlElement element in Month)
                        {
                            if (element.InnerText == Information[0].Expiry.Substring(0, 2))
                            {
                                SupremeMonth.SetAttribute("value", Information[0].Expiry.Substring(0,2));
                                SupremeMonth.InvokeMember("onchange");
                                SupremeMonth.InvokeMember("click");

                                break;
                            }
                        }

                        System.Windows.Forms.HtmlElement SupremeYear = null;

                        SupremeYear = Form1.SupremeYear;

                        System.Windows.Forms.HtmlElementCollection Year = SupremeYear.Children;

                        foreach (System.Windows.Forms.HtmlElement element in Year)
                        {
                            if (element.InnerText == Information[0].Expiry.Substring(2, 5).Trim())
                            {
                                SupremeYear.SetAttribute("value", Information[0].Expiry.Substring(2, 5).Trim());
                                SupremeYear.InvokeMember("onchange");
                                SupremeYear.InvokeMember("click");

                                break;
                            }
                        }

                        #endregion          

                        #region Textbox value event

                        System.Windows.Forms.HtmlElement SupremeCartCC = null;

                        SupremeCartCC = Form1.SupremeCartCC;

                        SupremeCartCC.Document.GetElementById("cnb").SetAttribute("value", Information[0].Number);
                        SupremeCartCC.Document.GetElementById("vval").SetAttribute("value", Information[0].Cvv);

                        #endregion
                        
                        #region Checkbox event

                        System.Windows.Forms.HtmlElementCollection Term = null;

                        Term = Form1.SupremeTerm;

                        foreach (System.Windows.Forms.HtmlElement element in Term)
                        {
                            if (element.GetAttribute("className") == "icheckbox_minimal")
                            {
                                if (element.FirstChild.Id == "order_terms")
                                {
                                    element.SetAttribute("className", "icheckbox_minimal checked");

                                    break;
                                }
                            }
                        }

                        #endregion

                        #region Button event

                        System.Windows.Forms.HtmlElement SupremeProcessButton = null;

                        SupremeProcessButton = Form1.SupremeProcessButton;

                        System.Windows.Forms.HtmlElementCollection Pay = SupremeProcessButton.Children;

                        foreach (System.Windows.Forms.HtmlElement element in Pay)
                        {
                            if (element.GetAttribute("value").Equals("process payment"))
                            {
                                element.InvokeMember("click");

                                break;
                            }
                        }

                        #endregion

                        #endregion

                        Thread.Sleep(5000);

                        Form1.BotBuddha(2);

                        Thread.Sleep(3000);

                        PurchasedItems.Add(Item);

                        Items.Remove(Item);

                        if (PurchasedItems.Count != Proposal.Count)
                        {
                            Form1.BotBuddha(3);
                        }
                        else
                        {
                            Form1.BotBuddha(0);
                        }
                    }
                    catch (Exception) { }

                    #endregion
                }
            }
        }

        int Compute(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }


            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
                }
            }

            return d[n, m];
        }

        string GetSubstringByString(string a, string b, string c)
        {
            return c.Substring((c.IndexOf(a) + a.Length), (c.IndexOf(b) - c.IndexOf(a) - a.Length));
        }

        string FormatType(string _type)
        {
            string tmp = null;

            switch (_type)
            {
                case "Visa":
                    tmp = "visa";
                    break;

                case "American Express":
                    tmp = "american_express";
                    break;

                case "Mastercard":
                    tmp = "master";
                    break;

                case "Solo":
                    tmp = "solo";
                    break;

                case "Paypal":
                    tmp = "paypal";
                    break;
            }

            return tmp;
        }
    }

    class SupremeList : List<SupremeItem>
    {
        public bool Executed { get; set; }

        public SupremeList()
        {
            this.Clear();

            Executed = false;
        }

        public SupremeList(int i)
        {
            this.Clear();

            HtmlAgilityPack.HtmlDocument doc = null;

            if (!Executed)
            {
                try
                {
                    doc = new HtmlAgilityPack.HtmlDocument();

                    switch (i)
                    {
                        case 0:
                            doc.LoadHtml(new WebClient().DownloadString("http://www.supremenewyork.com/shop/all"));
                            break;

                        case 1:
                            doc.LoadHtml(new WebClient().DownloadString("http://www.supremenewyork.com/"));
                            doc.LoadHtml(new WebClient().DownloadString("http://www.supremenewyork.com" + PreviewLink(doc.DocumentNode.Descendants("li")) + "/all"));
                            break;
                    }
                    
                    Executed = true;
                }
                catch (Exception)
                {
                    Executed = false;
                }
            }

            if (Executed)
            {
                PopulateWith(i, doc.DocumentNode.Descendants("article"));
            }
        }

        public SupremeList(IEnumerable _elements)
        {
            this.Clear();

            if (!Executed)
            {
                try
                {
                    PopulateWith(2, _elements);

                    Executed = true;
                }
                catch (Exception)
                {
                    Executed = false;
                }
            }
        }

        string PreviewLink(IEnumerable<HtmlNode> _elements)
        {
            HtmlNode node = _elements.Skip(1).FirstOrDefault();

            return node.SelectSingleNode("a").Attributes[0].Value;
        }

        void PopulateWith(int i, IEnumerable _elements)
        {
            foreach (HtmlNode node in _elements)
            {
                try
                {
                    switch (i)
                    {
                        case 0:
                          //-----//
                            #region SS14

                            // HTML DOCUMENTATION

                            /*
                                    <!DOCTYPE html>

                                    <html class=" js no-touch csstransforms" lang="en" style="">

                                        <head></head>
                                        <body class=" products view-all us">
                                            <header id="header" style="opacity: 1;"></header>
                                            <div id="wrap" style="opacity: 1;">
                                                <nav class="sidebar" style="opacity: 1;"></nav>
                                                <div id="container" style="opacity: 1;">
                                                    <article>
                                                        <a href="/shop/jacket/cotton-ripstop-n-3b-parka/desert-camo">
                                                            <img width="84" height="84" src="//d17ol771963kd3.cloudfront.net/93236/vi/O53mRSOJ32w.jpg" alt="Cotton Ripstop N-3B Parka"></img>
                                                        </a>
                                                    </article>
                                                    <article></article>
                                                    <article></article>
                                                    <article></article>
                                                    <article></article>
                                                </div>
                                            </div>
                                        </body>

                                    </html>
                            */

                            // this.Add(new SupremeItem(node.SelectSingleNode("a/img").Attributes[0].Value, node.SelectSingleNode("a/img").Attributes[2].Value, node.SelectSingleNode("a").Attributes[0].Value, node.Descendants("div").Any(div => div.Attributes["class"] != null && div.Attributes["class"].Value == "sold_out_tag")));

                            #endregion
                          //-----//
                            #region SS15

                            // HTML DOCUMENTATION

                            /*
                                    <!DOCTYPE html>

                                    <html class=" js no-touch csstransforms" lang="en" style="">

                                        <head></head>
                                        <body class=" products view-all us">
                                            <header id="header" style="opacity: 1;"></header>
                                            <div id="wrap" style="opacity: 1;">
                                                ::before
                                                <nav class="sidebar" style="opacity: 1;"></nav>
                                                <div id="container" style="opacity: 1;">
                                                    <article>
                                                      <div class="inner-article">
                                                        <a style="height:81px;" href="/shop/jackets/reversible-cotton-ma-1/blue-camo">
                                                          <img width="81" height="81" src="//d17ol771963kd3.cloudfront.net/101966/vi/Hco78lHlLKI.jpg" alt="Reversible Cotton MA-1"></img>
                                                         </a>
                                                      </div>
                                                    </article>
                                                    <article></article>
                                                    <article></article>
                                                    <article></article>
                                                    <article></article>
                                                </div>
                                            </div>
                                        </body>

                                    </html>
                            

                            if (node.SelectSingleNode("div/a").Attributes[0].Value.Equals("/shop/skate/cherry/dvd"))
                            {
                                this.Add(new SupremeItem("cherry", node.SelectSingleNode("div/a/img").Attributes[3].Value, node.SelectSingleNode("div/a").Attributes[0].Value, node.Descendants("div").Any(div => div.Attributes["class"] != null && div.Attributes["class"].Value == "sold_out_tag")));
                            }
                            else
                            {
                                this.Add(new SupremeItem(node.SelectSingleNode("div/a/img").Attributes[0].Value, node.SelectSingleNode("div/a/img").Attributes[2].Value, node.SelectSingleNode("div/a").Attributes[0].Value, node.Descendants("div").Any(div => div.Attributes["class"] != null && div.Attributes["class"].Value == "sold_out_tag")));
                            }
                            */
                            #endregion
                          //-----//
                            #region SS16

                            HtmlAgilityPack.HtmlDocument EncryptedName = null;

                            EncryptedName = new HtmlAgilityPack.HtmlDocument();
                            EncryptedName.LoadHtml(new WebClient().DownloadString("http://www.supremenewyork.com" + node.SelectSingleNode("div/a").Attributes[0].Value));

                            this.Add(new SupremeItem(EncryptedName.DocumentNode.SelectSingleNode("//div[@id='details'] //h1").InnerText, node.SelectSingleNode("div/a/img").Attributes[2].Value, node.SelectSingleNode("div/a").Attributes[0].Value, node.Descendants("div").Any(div => div.Attributes["class"] != null && div.Attributes["class"].Value == "sold_out_tag")));

                            #endregion
                          //-----//
                            break;

                        case 1:
                            this.Add(new SupremeItem(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(node.SelectSingleNode("div/a").Attributes[0].Value.Split('/').Last().Replace("-", " ")), node.SelectSingleNode("div/a/img").Attributes[2].Value, node.SelectSingleNode("div/a").Attributes[0].Value));
                            break;

                        case 2:
                            this.Add(new SupremeItem(node.SelectSingleNode("a").Attributes[0].Value, Convert.ToBoolean(node.SelectSingleNode("a").Attributes[4].Value), node.SelectSingleNode("a").Attributes[6].Value));
                            break;
                    }
                }
                catch (Exception)
                {
                    this.Add(new SupremeItem());
                }
            }
        }
    }

    class SupremeItem
    {
        internal string Name { get; set; }
        
        internal string Product { get; set; }
        
        internal string Href { get; set; }
        
        internal bool Sold { get; set; }

        internal string Design { get; set; }

        public SupremeItem()
        {
            Name = string.Empty;
            Product = string.Empty;
            Href = string.Empty;
        }

        public SupremeItem(string _name, string _product, string _href)
        {
            Name = _name;
            Product = _product;
            Href = _href;
        }

        public SupremeItem(string _href, bool _sold, string _design)
        {
            Href = _href;
            Sold = _sold;
            Design = _design;
        }

        public SupremeItem(string _name, string _product, string _href, bool _sold)
        {
            Name = _name;
            Product = _product;
            Href = _href;
            Sold = _sold;
        }
    }

    class SupremeComparer : IEqualityComparer<SupremeItem>
    {
        public bool Equals(SupremeItem x, SupremeItem y)
        {
            if (x == null || y == null)
            {
                return false;
            }

            bool equals = x.Sold == y.Sold;

            return equals;
        }

        public int GetHashCode(SupremeItem obj)
        {
            if (obj == null)
            {
                return int.MinValue;
            }

            int hash = obj.Sold.GetHashCode();

            return hash;
        }
    }

    //**************************************************************************
    //****************************************PROPERTY OF KASMER|SHROOMS|GOOMBA*
}

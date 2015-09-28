using System;
using System.Web;


/*Cookie format:
    Antall = 2 -> antall elementer i handlevognen
    ProduktNavn 1 -> navnet på produkt 1, byttes ut med produktId senere
    ProduktAntall 1 -> antall produk 1 som er bestillt
    ProduktNavn 2 -> navnet på produkt 2, byttes ut med produktId senere
    ProduktAntall 2 -> antall produk 2 som er bestillt
    ...
*/

public class CookieHandler
{

    public const string SHOPPING_CART_COOKIE = "shopping_cart";
    public const string ELEMENTS_IN_CART = "elements";
    public const string PRODUCT_NAME = "product_name";
    public const string PRODUCT_QUANTITY = "product_quantity";

    //The default is given in days
    public const int DEFAULT_EXPIRATION = 1;

    public static bool doesCookieExist(string cookieIdentifier)
    {
        return HttpContext.Current.Request.Cookies[cookieIdentifier] != null;
    }

    public static HttpCookie getCookie(string cookieIdentifier)
    {
        return HttpContext.Current.Request.Cookies[cookieIdentifier];
    }


    public static bool changeCartElement(string productName, string newQuantity)
    {

        HttpCookie cartCookie = HttpContext.Current.Request.Cookies[SHOPPING_CART_COOKIE];
        string elementQuantityStr = cartCookie.Values[ELEMENTS_IN_CART];

        int elementQuantity = Convert.ToInt32(elementQuantityStr);

        for (int i = 1; i <= elementQuantity; i++)
        {
            string current = Convert.ToString(i);
            if (cartCookie.Values[PRODUCT_NAME + current] == productName)
            {
                cartCookie.Values[PRODUCT_QUANTITY] = newQuantity;
                HttpContext.Current.Response.Cookies.Add(cartCookie);
                return true;
            }
        }
        return false;

    }

    public static bool removeElementFromCart(string productName)
    {

        HttpCookie cartCookie = HttpContext.Current.Request.Cookies[SHOPPING_CART_COOKIE];

        int elementQuantity = Convert.ToInt32(cartCookie.Values[ELEMENTS_IN_CART]);

        //Delete the entire cookie if there is only 1 element
        if (elementQuantity == 1)
        {
            cartCookie.Expires = DateTime.Now.AddDays(-1d);
            HttpContext.Current.Response.Cookies.Add(cartCookie);
            return true;
        }

        for (int i = 1; i <= elementQuantity; i++)
        {
            string current = Convert.ToString(i);

            if (cartCookie.Values[PRODUCT_NAME + current] == productName)
            {

                for (int j = i; j < elementQuantity; j++)
                {
                    string innerCurrent = Convert.ToString(j);
                    string nextInner = Convert.ToString(j + 1);

                    cartCookie.Values[PRODUCT_NAME + innerCurrent] = cartCookie.Values[PRODUCT_NAME + nextInner];
                    cartCookie.Values[PRODUCT_QUANTITY + innerCurrent] = cartCookie.Values[PRODUCT_QUANTITY + nextInner];
                }

                string newElementQuantity = Convert.ToString(elementQuantity - 1);
                cartCookie.Values[ELEMENTS_IN_CART] = newElementQuantity;

                string last = Convert.ToString(elementQuantity);

                cartCookie.Values.Remove(PRODUCT_NAME + last);
                cartCookie.Values.Remove(PRODUCT_QUANTITY + last);

                HttpContext.Current.Response.Cookies.Add(cartCookie);
                return true;
            }
        }

        return false;

    }

    
    public static void addElementToCart(string productName, string productQuantity, int daysUntilExpire = DEFAULT_EXPIRATION)
    {

        //Legg til test for å sjekke at cookien ikke blir større enn 4096 bytes

        if (HttpContext.Current.Request.Cookies[SHOPPING_CART_COOKIE] == null)
        {
            //Create new cookie

            HttpContext.Current.Response.Cookies[SHOPPING_CART_COOKIE][ELEMENTS_IN_CART] = "1";
            HttpContext.Current.Response.Cookies[SHOPPING_CART_COOKIE][PRODUCT_NAME + "1"] = productName;
            HttpContext.Current.Response.Cookies[SHOPPING_CART_COOKIE][PRODUCT_QUANTITY + "1"] = productQuantity;
            HttpContext.Current.Response.Cookies[SHOPPING_CART_COOKIE].Expires = DateTime.Now.AddDays(daysUntilExpire);
        }
        else
        {

            //Append to existing cookie

            HttpCookie cartCookie = HttpContext.Current.Request.Cookies[SHOPPING_CART_COOKIE];

            string elementQuantity = cartCookie.Values[ELEMENTS_IN_CART];
            string newElementQuantity = Convert.ToString((Convert.ToInt32(elementQuantity) + 1));

            cartCookie.Values[ELEMENTS_IN_CART] = newElementQuantity;
            cartCookie.Values[PRODUCT_QUANTITY + newElementQuantity] = productQuantity;
            cartCookie.Values[PRODUCT_NAME + newElementQuantity] = productName;

            cartCookie.Expires = DateTime.Now.AddDays(daysUntilExpire);
            HttpContext.Current.Response.Cookies.Add(cartCookie);
        }


    }//end of addElementToCart

}
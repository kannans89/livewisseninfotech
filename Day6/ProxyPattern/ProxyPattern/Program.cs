

using ProxyPattern;

CaseStudy2();

 static void CaseStudy2()
{
    var doc1 = new DocumentProxy("doc1.pdf");
    var doc2 = new DocumentProxy("doc2.pdf");
    var doc3 = new DocumentProxy("doc3.pdf");

    //doc3.DisplayDocument();
    doc3.DisplayDocument();
}



static void CaseStudy1()
{
    var doc1 = new Dcoument("doc1.pdf");
    var doc2 = new Dcoument("doc2.pdf");
    var doc3 = new Dcoument("doc3.pdf");

    doc3.DisplayDocument();
}
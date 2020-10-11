exports.header = {
    height: "1cm",
    contents: function(pageNum, numPages) {
        return "<h1>HEADER <span style='float:right'>" + pageNum + " / " + numPages + "</span></h1>"
    }
 };

exports.footer = {
    height: "1cm",
    contents: function(pageNum, numPages) {
        if (pageNum == numPages) {
            return "";
        }
        return "<h1>FOOTER <span style='float:right'>" + pageNum + " / " + numPages + "</span></h1>";
    }
}

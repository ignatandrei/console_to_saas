'use strict';
console.log(`start print`);

var markdownpdf = require("markdown-pdf")

var mdDocs = [
	"README.md","Chapter01/readme.md", "Chapter02/readme.md","Chapter03/readme.md","Chapter04/readme.md"
	]
  , bookPath = "book.pdf"

markdownpdf().concat.from(mdDocs).to(bookPath, function () {
  console.log("Created", bookPath)
})
'use strict';
console.log(`start print`);

var markdownpdf = require("markdown-pdf")

var mdDocs = [
	"readme.md","Chapter01/readme.md", "Chapter02/readme.md"
	]
  , bookPath = "book.pdf"

markdownpdf().concat.from(mdDocs).to(bookPath, function () {
  console.log("Created", bookPath)
})
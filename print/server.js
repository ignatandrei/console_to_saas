"use strict";
(async () => {
console.log(`start print`);
const { badgen } = require("badgen");
const sloc = require("node-sloc");
const fs = require("fs");
const chapters = [
  "Chapter01",
  "Chapter02",
  "Chapter03",
  "Chapter04",
  "Chapter05",
  "Chapter06",
  "Chapter07",
];

for (var i = 0; i < chapters.length; i++) {
  var item = chapters[i];
  var res= await sloc({ path: `../${item}/` });
  console.log(res);
    const svgString = badgen({
      label: `${item}`, // <Text>
      labelColor: "ADF", // <Color RGB> or <Color Name> (default: '555')
      status: `files:${res.sloc.files};lines:${res.sloc.loc}`, // <Text>, required
      color: "blue", // <Color RGB> or <Color Name> (default: 'blue')
      style: "flat", // 'flat' or 'classic' (default: 'classic')
      //icon: 'data:image/svg+xml;base64,...', // Use icon (default: undefined)
      //iconWidth: 13,    // Set this if icon is not square (default: 13)
      scale: 1, // Set badge scale (default: 1)
    });
    fs.writeFileSync(`../${item}.svg`, svgString);
  
}


var markdownpdf = require("markdown-pdf");

var mdDocs = [
    "../README.md",
    "../1-break.md",
    "../Chapter01/readme.md",
    "../1-break.md",
    "../Chapter02/readme.md",
    "../1-break.md",
    "../Chapter03/readme.md",
    "../1-break.md",
    "../Chapter04/readme.md",
    "../1-break.md",
    "../Chapter05/readme.md",
    "../1-break.md",
    "../Chapter06/readme.md",
    "../1-break.md",
    "../Chapter07/readme.md"
  ],
  bookPath = "../book.pdf";

//   function preProcessMd () {
//     return through(function(data) {
//         pageBreak = '\n\n<div style="page-break-before: always;"></div>\n\n'

//         this.queue(data + pageBreak)
//     })
// }



markdownpdf({
  runningsPath: 'running.js'
})
  .concat.from(mdDocs)
  .to(bookPath, function () {
    console.log("Created", bookPath);
  });

})();
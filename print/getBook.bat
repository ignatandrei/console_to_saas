docker build -t ignatandrei/printsaas .. -f ./exportPDF.txt  
docker run -d --name printsaas  ignatandrei/printsaas
docker cp printsaas:/usr/src/book.pdf .
docker cp printsaas:/usr/src/Chapter01/lines.md ../Chapter01/lines.md
docker container kill printsaas
docker container rm printsaas
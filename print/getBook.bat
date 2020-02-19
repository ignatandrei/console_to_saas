docker build -t ignatandrei/printsaas .. -f .\exportPDF.txt  
docker run -d --name printsaas  ignatandrei/printsaas
docker cp printsaas:/usr/app/book.pdf .
docker container kill printsaas
docker container rm printsaas
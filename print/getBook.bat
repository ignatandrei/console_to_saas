docker build -t ignatandrei/printsaas .. -f ./exportPDF.txt  
docker run -d --name printsaas  ignatandrei/printsaas
docker cp printsaas:/usr/src/book.pdf .
docker cp printsaas:/usr/src/Chapter01.svg .
docker cp printsaas:/usr/src/Chapter02.svg .
docker cp printsaas:/usr/src/Chapter03.svg .
docker cp printsaas:/usr/src/Chapter04.svg .
docker cp printsaas:/usr/src/Chapter05.svg .
docker container kill printsaas
docker container rm printsaas
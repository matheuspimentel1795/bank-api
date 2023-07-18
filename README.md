# bank-api
1) Acessar a pasta ApiUserBank ex : cd ApiUserBank

2)  rodar o comando: docker build -t apiuse .

3)  rodar o comando:  docker run -t -p 8080:80 -e ASPNETCORE_ENVIRONMENT=Development --restart=unless-stopped apiuse .

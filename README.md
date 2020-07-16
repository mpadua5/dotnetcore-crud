# dotnetcore-crud

|Database|Backend|Frontend|
|--------|-------|--------|
|MySQL   | dotnetcore | VueJS

---

#### Dependências

Definir as seguintes variáveis de ambiente:

`DB_HOST`
`DB_PORT`
`DB_USER`
`DB_PASSWORD`
`DB_NAME`
`APPLICATION_NAME`
`VUE_APP_API_URL`

Valores sugeridos:

    export DB_HOST=localhost \
    export DB_PORT=3306 \
    export DB_USER=root \
    export DB_PASSWORD=root \
    export DB_NAME=dotnetcorecrud \
    export APPLICATION_NAME=dotnetcore-crud \
    export VUE_APP_API_URL=localhost:19000
---
### Execução

Todo o projeto está em Docker. O frontend e backend possuem seus Dockerfiles para criação de suas imagens própriamente ditas.
Para sua execução, entrar no path onde contem o arquivo docker-compose e executar o seguinte comando:

	docker-compose up -d --build

***Obs:* Executar o comando acima após definir as variáveis de ambiente.**

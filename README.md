# ReviewFilmes

API desenvolvida em .NET Core utilizando MVC e EntityFramework.

Diagrama de classes: https://prnt.sc/U-gMxF6rMoyS

Nesta API é possível consultar, cadastrar e excluir filmes e suas respectivas avaliações.

Para os filmes, é possível consultar todos os filmes cadastrados, procurar por ID ou verificar a média da nota de um filme específico (pesquisa por ID também);
Também é possível cadastrar um novo filme, apenas é necessário título do filme e gênero (toda a parte de banco de dados é gerenciada pelo entity framework, então não existe nenhuma query ou procedure por parte do banco, o código faz toda a parte de consulta, gravação e exclusão de registros). Ao excluir um filme, todas as suas avaliações também serão excluídas.

Assim como os filmes, as avaliações também podem ser consultadas, gravadas e excluídas. É possível consultar uma avaliação pelo ID do filme ou apenas trazer todas juntas.
Para gravar é necessário informar um título da sua avaliação, o ID do filme, sua nota para o filme e logo abaixo a sua opinião sobre.
Para excluir é necessário apenas o ID da review.

A banco de dados é integrado à plataforma Azure e sua conexão é feita direto pelo projeto.

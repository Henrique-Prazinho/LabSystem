# LabSystem

LabSystem é um sistema de cadastro de **Clientes**, **Fornecedores** e **Produtos**, desenvolvido utilizando **ASP.NET MVC**.

## Funcionalidades

- **Cadastro de Clientes**: Na tela inicial, o cliente pode realizar o login. Caso ainda não tenha uma conta, ele pode se cadastrar clicando no botão **"Cadastro"**, localizado no canto superior esquerdo.

- **Cadastro de Fornecedores/Produtos**: Apenas o **Administrador** tem permissão para acessar a funcionalidade de cadastro de fornecedores e produtos. Após realizar o login, o administrador poderá cadastrar, editar, excluir e listar produtos e fornecedores, realizando todas as operações CRUD.

## Banco de Dados

- **Provedor**: MySQL (usando o **Pomelo.EntityFrameworkCore.MySql**)

- **DBSets criados**:
  - `User`
  - `Products`

A string de conexão está localizada no arquivo **"Secrets.json"**, que é ignorado pelo `.gitignore`.

## Configuração de Sessão

A funcionalidade de autenticação e a validação de privilégios ainda não estão totalmente implementadas.

## Atribuições de Acesso

- **Customer**: Acesso somente para visualização dos produtos.

- **Admin**: Acesso completo para manipulação e criação de produtos/fornecedores.

- **Supplier**: Não implementado.

## Acesso a conta de Administrador
- Admin Email: admin@gmail.com
- Admin Password: admin123

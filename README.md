# API DE PROCESSAMENTO DE VENDAS
Foi construido uma API REST utilizando .NET que simula um processo de venda. A mesma não possui mecanismo de autenticação mas,
possui persistência em um banco de dados.

## A CONSTRUÇÃO
- A API e possui 5 operações:
  1) Registrar venda: Recebe os dados do vendedor + itens vendidos. Registra venda com status "Aguardando pagamento";
  2) Buscar todas as vendas;
  3) Buscar venda: Busca pelo Id da venda;
  4) Atualizar venda: Permite que seja atualizado o status da venda.
     * OBS.: Possíveis status: `Pagamento aprovado` | `Enviado para transportadora` | `Entregue` | `Cancelada`.
    - Uma venda contém informação sobre o vendedor que a efetivou, data, identificador do pedido e os itens que foram vendidos;
    - O vendedor deve possuir id, cpf, nome, e-mail e telefone;
    - A inclusão de uma venda deve possuir pelo menos 1 item;
    - A atualização de status deve permitir somente as seguintes transições: 
      - De: `Aguardando pagamento` Para: `Pagamento Aprovado`
      - De: `Aguardando pagamento` Para: `Cancelada`
      - De: `Pagamento Aprovado` Para: `Enviado para Transportadora`
      - De: `Pagamento Aprovado` Para: `Cancelada`
      - De: `Enviado para Transportador`. Para: `Entregue`
  5) Uma venda só poderá ser excluida se estiver com o Status `Cancelada` e for de uma data menor que 60 dias.

## ENDPOINTS
- [HttpPost] </br>
     Request URL = `https://localhost:7071/Vendas`
Grava um JSON da venda no formato: </br>
    ```
    {
          "idVenda": 0,
          "vendedorId": 0,
          "vendedorName": "string",
          "email": "string",
          "cpf": "string",
          "telefone": "string",
          "itensVendidos": "string",
          "status": "AguardandoPagamento",
          "data": "2022-11-01T23:32:06.788Z"
    }
    ```
- [HttpGet] </br>
   Retorna todas as vendas registradas. Request URL = `https://localhost:7071/Vendas` </br>

- [HttpGet("{id}")] </br>
   Necessita apenas do ID da venda que deseja consultar. Request URL = `https://localhost:7071/Vendas/idVenda` </br>

- [HttpPut("{id}")] </br>
Request URL = `https://localhost:7071/Vendas/idVenda` </br>   
É necessario passar o id da venda que se deseja atualizar mais os campos editaveis no formato abaixo: </br>
    ```
    {
          "status": "AguardandoPagamento"          
    }
    ```

- DELETE </br>
    Necessita apenas do ID da venda que deseja excluir </br>
   

## TECNOLOGIAS ENVOLVIDAS
- C#.NET
- API REST 
- SQL SERVER

## CONTATOS
[![Linkedin Badge](https://img.shields.io/badge/-LinkedIn-0072b1?style=for-the-badge&logo=Linkedin&logoColor=white)](https://www.linkedin.com/in/emmanuel-cosme-martins-bento-3963bb1b9/ 'Contato pelo LinkedIn')
[![Gmail Badge](https://img.shields.io/badge/-gmail-c14438?style=for-the-badge&logo=Gmail&logoColor=white)](mailto:emmanuelbento6@gmail.com 'Contato via Email')

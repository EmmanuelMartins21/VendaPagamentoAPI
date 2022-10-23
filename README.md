# API DE PROCESSAMENTO DE VENDAS
Foi construido uma API REST utilizando .NET que simula um processo de venda. A mesma não possui mecanismo de autenticação mas,
possui persistência em um banco de dados.

## A CONSTRUÇÃO
- A API e possui 3 operações:
  1) Registrar venda: Recebe os dados do vendedor + itens vendidos. Registra venda com status "Aguardando pagamento";
  2) Buscar venda: Busca pelo Id da venda;
  3) Atualizar venda: Permite que seja atualizado o status da venda.
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
- Uma venda só poderá ser excluida se estiver com o Status `Cancelada` e for de uma data menor que 60 dias.

## TECNOLOGIAS ENVOLVIDAS
- C#.NET
- API REST 
- SQL SERVER

## CONTATOS
[![Linkedin Badge](https://img.shields.io/badge/-LinkedIn-0072b1?style=for-the-badge&logo=Linkedin&logoColor=white)](https://www.linkedin.com/in/emmanuel-cosme-martins-bento-3963bb1b9/ 'Contato pelo LinkedIn')
[![Gmail Badge](https://img.shields.io/badge/-gmail-c14438?style=for-the-badge&logo=Gmail&logoColor=white)](mailto:emmanuelbento6@gmail.com 'Contato via Email')

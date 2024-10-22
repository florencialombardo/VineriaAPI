Para registrar un vino:
POST /api/wine
Body:
{
  "name": "Malbec",
  "variety": "Cabernet Sauvignon",
  "year": 2020,
  "region": "Mendoza",
  "stock": 100
}

Para consultar el inventario:
GET /api/wine

Para consultar un vino por nombre:
GET /api/wine/{name}

Para registrar un usuario:
POST /api/user
Body:
{
  "username": "usuario1",
  "password": "contraseñaSegura"
}

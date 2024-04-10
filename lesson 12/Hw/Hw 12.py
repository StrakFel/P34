import requests
import random

page = random.randint(1, 7438)
pageSize = 1
url =f'https://api.disneyapi.dev/character?pageSize={pageSize}&page={page}'
response = requests.get(url)

if response.ok:
    as_json = response.json()
    print(f" {as_json['data']['name']}")
    name = as_json['data']['name']
    print(f"Films:\n - {name} {as_json['data']['films']}\n")
    print('Short film:\n')
    print(f"TV shows:\n - {name} {as_json['data']['films']}\n")
    print(f"Video Games:\n - {name} {as_json['data']['videoGames']}")
else:
    print('Щось пішло не так...')
    print(f'{response.status_code=}')
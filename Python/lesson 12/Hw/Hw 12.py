import requests
import random

page = random.randint(1, 7438)
pageSize = 1
url =f'https://api.disneyapi.dev/character?pageSize={pageSize}&page={page}'
response = requests.get(url)

if response.ok:
    character = response.json()['data']

    print(f" {character['name']}")
    print('Films:')
    for film in character['films']:
        print(f"- {film}")
    print('\nShort film:\n')
    for Shortfilm in character['shortFilms']:
        print(f"- {Shortfilm}")
    print(f"TV shows:")
    for tvShow in character['tvShows']:
        print(f"- {tvShow}")
    print(f"\nVideo Games:")
    for videoGame in character['videoGames']:
        print(f"- {videoGame}")
else:
    print('Щось пішло не так...')
    print(f'{response.status_code=}')
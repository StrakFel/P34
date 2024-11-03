import requests

url = 'https://www.freeforexapi.com/api/live'
response = requests.get(url)
pairs = []

if response.ok:
    as_json = response.json()
    for pair in as_json['supportedPairs']:
        pairs.append(pair)
else:
    print('Щось прішло не так')
    print(f'{response.status_code=}')


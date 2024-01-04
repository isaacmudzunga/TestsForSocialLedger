import requests
import re
import subprocess
import time
import sys
import argparse


# ---
# Docker functions
# https://docker-py.readthedocs.io/en/stable/client.html
# ---
def status():
    subprocess.check_call(['docker', 'ps', '-a', '--filter', 'name=nopcommerce'])


def stop():
    output = subprocess.check_call(['docker-compose', '-p', 'nopcommercetest', '-f', './docker-compose.yml', 'down'])
    print(output)


def start():
    up()
    install()
    print('nopCommerce should now be reachable through http://localhost:90/')


def up():
    subprocess.check_call(['docker-compose', '-p', 'nopcommercetest', '-f', './docker-compose.yml', 'up', '-d'])
    print_and_sleep('Docker started, waiting 15 secs to give containers some time to start up....', 15)

# ---
# Configure nopCommerce
# ---
def install():
    print('Getting cookie required to start installation')
    url = 'http://localhost:90/install'
    res = requests.get(url)
    if res.status_code != 200:
        sys.exit('Error getting cookie!')

    regex_search = re.findall(re.escape('Cookie ') + '(.*)' + re.escape(' for'), str(res.cookies))
    if len(regex_search) == 1:
        required_cookie = regex_search[0]
    else:
        sys.exit('Error parsing cookie!')

    print('Starting installation process')
    install_headers = {
        'Connection': 'keep-alive',
        'Cache-Control': 'max-age=0',
        'Origin': 'http://localhost:90',
        'Upgrade-Insecure-Requests': '1',
        'DNT': '1',
        'Content-Type': 'application/x-www-form-urlencoded',
        'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9',
        'Sec-Fetch-Site': 'same-origin',
        'Sec-Fetch-Mode': 'navigate',
        'Sec-Fetch-User': '?1',
        'Sec-Fetch-Dest': 'document',
        'Referer': 'http://localhost:90/install',
        'Accept-Language': 'en-GB,en-US;q=0.9,en;q=0.8',
        'Cookie': required_cookie,
        'sec-gpc': '1'
    }
    install_data = 'AdminEmail=admin%40yourStore.com&AdminPassword=123&ConfirmPassword=123&Country=GB-en-US' \
                   '&InstallSampleData=true&DataProvider=3&ConnectionStringRaw=true&ServerName=&DatabaseName=&Username=&Password=' \
                   '&ConnectionString=Server%3Dnopcommerce_database%3BPort%3D5432%3BDatabase' \
                   '%3Dnop%3BUser%20Id%3Dpostgres%3BPassword%3DnopCommerce_db_password%3B' \
                   '&__RequestVerificationToken=CfDJ8HwM9cCm3UhEg4bV5AKWlwRHr5_tFZr3Cn5W87kMYLh3llFCO0lZC7BYIk3ku4LzSp4DLLLNKKfefxyHAnbW29cvR4V_lk9gxO_PDD387iGDrNpQfZXjNSDOEa2vjnFENDLmJKlaToXWdrj_OueTYUY' \
                   '&InstallSampleData=true&CreateDatabaseIfNotExists=true&ConnectionStringRaw=true&IntegratedSecurity=false&UseCustomCollation=false'
    install_request = requests.post('http://localhost:90/install', headers=install_headers, data=install_data)
    if install_request.status_code != 200:
        sys.exit('Error sending installation request')

    print_and_sleep('Sleeping 15 secs to give installation process a bit of time...', 15)

    print('Restarting main container')
    subprocess.check_call(['docker', 'restart', 'nopcommerce_web'])
    print_and_sleep('Sleeping 15 secs to give app time to startup', 15)


# ---
# Helper functions
# ---
def print_and_sleep(message, seconds):
    print(message)
    time.sleep(seconds)


# ---
# Configure command line args
# ---
parser = argparse.ArgumentParser()
parser.add_argument('-c', '--command',
                    choices=('start', 'stop', 'status' ),
                    dest='command',
                    required=False,
                    help='Specify command (start, stop, status)'
                    )

# ---
# Parse the command line args
# ---
args = parser.parse_args()
if len(sys.argv) == 1:
    print("No arguments provided.")
    parser.print_help()
    sys.exit()

# ---
# Run the commands
# ---
if args.command:
    if args.command == 'status':
        status()
    elif args.command == 'stop':
        stop()
    elif args.command == 'start':
        start()

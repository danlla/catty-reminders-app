#!/usr/bin/env bash
set -euo pipefail

APP_DIR=$1
VENV="$APP_DIR/.venv"
LOG="$APP_DIR/deploy.log"

exec > >(/usr/bin/tee -a "$LOG") 2>&1

echo "===== $(date '+%F %T') | START DEPLOY ====="

echo "Copy app files to app dir"

cp -r app static templates config.json $APP_DIR

echo "Prepare env file"
echo "DEPLOY_REF=$DEPLOY_REF" > $APP_DIR/.env

if [ ! -e "$VENV" ]; then
    echo "Virtualenv pip not found, creating ..."
    python3 -m venv $VENV
fi

if [ -e requirements.txt ]; then
    echo "Install python packages ..."
    "$VENV/bin/pip" install -r requirements.txt
fi

sudo systemctl restart app

echo "===== $(date '+%F %T') | DEPLOYMENT COMPLETED ====="
exit 0

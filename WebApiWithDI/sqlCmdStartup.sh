#wait for the SQL Server to come up
#sleep 60s

until nc -z -v -w30 localhost 1433
do
  echo "Waiting for database connection..."
  # wait for 5 seconds before check again
  sleep 5
done
#run the setup script to create the DB and the schema in the DB
#migrations

@ECHO off
echo Parsing all files in /data into /data_parsed


for %%F in (data\*.json) do (
   DiscordJSONParser\DiscordJSONParser\bin\Debug\net5.0\DiscordJSONParser %%F data_parsed\%%~nF.txt
)

pushd gpt-2\src
for %%F in (..\..\data_parsed\*.txt) do (
   echo Encoding %%F
   python encode.py --combine 10 %%F ..\..\data_encoded\%%~nF.npz
)
popd

echo Parsing complete
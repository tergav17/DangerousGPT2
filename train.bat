@ECHO off
echo Training encoded data from %1

pushd gpt-2\src
	python train.py --dataset ..\..\data_encoded\%1
popd
#!/bin/sh
# @echo on
clear
# title Building Server services ...

cur_dir=`pwd`
serv_home_dir=$cur_dir/..

# set info_color=02
# set error_color=04



include_ice_slice_dir=/usr/local//Cellar/ice/3.6.3_2/share/Ice-3.6.3/slice/
include_slice_dir=$serv_home_dir/../OnlineServices/src/main/slice
generated_dir=$serv_home_dir/../OnlineServices/generated


# for /r %include_slice_dir% %%i in (*.ice) do slice2cs -I$include_ice_slice_dir  -I$include_slice_dir --output-dir $generated_dir  %%i

for slice_file in  `ls  $include_slice_dir/*.ice`
do 
	slice2java -I$include_ice_slice_dir  -I$include_slice_dir --output-dir $generated_dir  $slice_file
done 

erase /Q "../GraphicsClient/fbb/"
erase /Q "../TCPServer/fbb/"
erase /Q "../../UnityClient/Assets/fbb/"

(for %%a in (fbs/*.fbs) do ( 
flatc.exe -n --scoped-enums --gen-object-api --natural-utf8 --cs-gen-json-serializer -b -o ../GraphicsClient/fbb fbs/%%a
flatc.exe -n --scoped-enums --gen-object-api --natural-utf8 --cs-gen-json-serializer -b -o ../../UnityClient/Assets/fbb fbs/%%a
flatc.exe -n --scoped-enums --gen-object-api --natural-utf8 --cs-gen-json-serializer -b -o ../TCPServer/fbb fbs/%%a
))


pause



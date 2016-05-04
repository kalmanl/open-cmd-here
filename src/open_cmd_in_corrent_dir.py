import sys
import os

try:
	path = sys.argv[1]
except:
	print("error did not get path")
	path = os.path.dirname(__file__)
	
stream = os.popen("start cmd.exe /k cd "+path)
	
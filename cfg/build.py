'''
Created on 09.10.2015

@author: 'D065230'
'''

import spi
import log
import subprocess
import os
from xmake_exceptions import XmakeException

class build(spi.BuildPlugin):
	def __init__(self, build_cfg):              
		self.build_cfg = build_cfg
	def run(self):
		cwd=os.path.abspath('Packages/FAKE.3.35.2/tools/Fake.exe') + ' src/XMake_build.fsx android-package'
		retcode=subprocess.call(cwd, shell=True)
		if retcode != 0:
			raise XmakeException('Error while building the application...')
#		log.info( 'building..' )
#		subprocess.call(['fake','src/XMake_build.fsx android-package'], shell=True)


import json
import psutil
import cpuinfo

cpu_name = cpuinfo.get_cpu_info()['brand_raw']

stats = {
    "cpu_utilization": psutil.cpu_percent(),
    "cpu_name": cpu_name,
    "cpu_threads": psutil.cpu_count(logical=True),
    "ram": psutil.virtual_memory().percent
}
print(json.dumps(stats))
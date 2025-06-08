using System;
using CecSharp;
using LibCECTray.Properties;

namespace LibCECTray.controller.actions
{
    class SendRawCommand : UpdateProcess
    {
        private string _hexCommand;
        private readonly LibCecSharp _lib;

        public SendRawCommand(LibCecSharp lib, string hexCommand)
        {
            _lib = lib;
            _hexCommand = hexCommand;
        }

        public override void Process()
        {
            SendEvent(UpdateEventType.StatusText, Resources.send_raw_command);
            SendEvent(UpdateEventType.ProgressBar, 10);

            try
            {
                // Parse the hex command string (format: xx:xx:xx:xx)
                string[] parts = _hexCommand.Split(':');

                // Parse first byte to extract source and destination
                byte firstByte = Convert.ToByte(parts[0], 16);
                byte opcodeByte = Convert.ToByte(parts[1], 16);

                // Extract source (upper 4 bits) and destination (lower 4 bits)
                CecLogicalAddress source = (CecLogicalAddress)((firstByte >> 4) & 0x0F);
                CecLogicalAddress destination = (CecLogicalAddress)(firstByte & 0x0F);

                // Create and configure the CEC command
                var command = new CecCommand();
                command.Initiator = source;
                command.Destination = destination;
                command.Opcode = (CecOpcode)opcodeByte;
                command.TransmitTimeout = 0;
                command.Eom = true;
                command.Ack = false;

                // Add any parameter bytes (from index 2 onwards)
                for (int i = 2; i < parts.Length; i++)
                {
                    byte param = Convert.ToByte(parts[i], 16);
                    command.Parameters.PushBack(param);
                }

                // Send the command
                bool result = _lib.Transmit(command);

                if (result)
                {
                    SendEvent(UpdateEventType.StatusText, $"Command {_hexCommand} sent successfully");
                }
                else
                {
                    SendEvent(UpdateEventType.StatusText, $"Failed to send command {_hexCommand}");
                }
            }
            catch (Exception ex)
            {
                SendEvent(UpdateEventType.StatusText, $"Error parsing/sending command: {ex.Message}");
            }
            finally
            {
                SendEvent(UpdateEventType.ProgressBar, 100);
            }
        }
    }
}